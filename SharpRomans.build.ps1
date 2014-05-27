properties {
	$configuration = 'Debug'
	$base_dir  = resolve-path .	
	$release_path = "$base_dir\release"
}

task default -depends Clean, Compile, Test, Deploy, Pack

task Clean {
	exec { msbuild .\SharpRomans.sln /t:clean /p:configuration=$configuration /m }
	Remove-Item $base_dir\*.htm -Force
	Remove-Item $base_dir\*.xml -Force
	Remove-Item $release_path -Recurse -Force -ErrorAction SilentlyContinue | Out-Null
}

task Compile {
	exec { msbuild .\SharpRomans.sln /p:configuration=$configuration /m }
}

task Test {
	Ensure-Release-Folders $release_path

	$test = Test-Assembly $base_dir $configuration 'SharpRomans'
	
	Run-Tests $base_dir $release_path ($test)
	Report-On-Test-Results $base_dir
}

task Deploy {
	$release_folders = Ensure-Release-Folders  $release_path
	$bin = Bin-Folder $base_dir $configuration "SharpRomans"
		
	Get-ChildItem -Path $bin -Filter 'SharpRomans*.dll' |
		Copy-To $release_folders

	Get-ChildItem -Path ($bin) -Filter 'SharpRomans*.pdb' |
		Copy-Item -Destination $release_path

	Get-ChildItem -Path ($bin) -Filter 'SharpRomans*.xml' |
		Copy-To $release_folders

	 Get-ChildItem $base_dir -Filter '*.nuspec' |
		Copy-Item -Destination $release_path
}

task Pack {
	Ensure-Release-Folders $release_path

	$nuget = "$base_dir\tools\nuget\nuget.exe"

	Get-ChildItem -File -Filter '*.nuspec' -Path $release_path  | 
		ForEach-Object { exec { & $nuget pack $_.FullName /o $release_path } }
}

function Test-Assembly($base, $config, $name)
{
	return "$base\src\$name.Tests\bin\$config\$name.Tests.dll"
}

function Bin-Folder($base, $config, $name)
{
	$project = Src-Folder $base $name
	return Join-Path $project "bin\$config\"
}

function Src-Folder($base, $name)
{
	return "$base\src\$name\"
}

function Run-Tests($base, $release, $test_assemblies){
	$nunit_console = "$base\tools\NUnit.Runners.lite.2.6.3.20131019\nunit-console.exe"

	exec { & $nunit_console $test_assemblies /nologo /nodots /result="$release\TestResult.xml"  }
}

function Report-On-Test-Results($base)
{
	$nunit_summary_path = "$base\tools\NUnitSummary"
	$nunit_summary = Join-Path $nunit_summary_path "nunit-summary.exe"

	$alternative_details = Join-Path $nunit_summary_path "AlternativeNUnitDetails.xsl"
	$alternative_details = "-xsl=" + $alternative_details

	exec { & $nunit_summary $release_path\TestResult.xml -html -o="release\TestSummary.htm" }
	exec { & $nunit_summary $release_path\TestResult.xml -html -o="release\TestDetails.htm" $alternative_details -noheader }
}

function Ensure-Release-Folders($base)
{
	$release_folders = ($base, "$base\lib\net40-client")

	foreach ($f in $release_folders) { md $f -Force | Out-Null }

	return $release_folders
}

function Copy-To($destinations)
{
	Process { foreach ($d in $destinations) { Copy-Item -Path $_.FullName -Destination $d } }
}