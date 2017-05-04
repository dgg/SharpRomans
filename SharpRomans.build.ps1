param(
	[ValidateSet('Debug', 'Release')]
	$Configuration = 'Release'
)
$release_dir = Join-Path $BuildRoot release
$solution_file = Join-Path $BuildRoot SharpRomans.sln 

task Clean {
	exec { dotnet clean $solution_file -c $Configuration -v m }

	Remove-Item -Path $release_dir -Force -Recurse | Out-Null
	New-Item -ItemType Directory $release_dir -Force | Out-Null
}

task Compile Clean, {
	exec { dotnet restore $solution_file }
	exec { dotnet build $solution_file -c $Configuration -v m }
}

task Test Clean, {
	$test_dir = Join-Path $BuildRoot src\SharpRomans.Tests
	$html_report = Join-Path $release_dir TestResult.html
	cd $test_dir
	exec { dotnet xunit -configuration $Configuration -nologo -html $html_report }
	cd $BuildRoot

	$bin_dir = Join-Path $test_dir "bin\$Configuration\net46"
	$html_report = Join-Path $bin_dir BDDfy.html
	$markdown_report = Join-Path $bin_dir BDDfy.md
	Copy-Item -Path ($html_report, $markdown_report) -Destination $release_dir
}

task Pack Test, {
	$proj_dir = Join-Path $BuildRoot src\SharpRomans
	exec { dotnet pack  (Join-Path $proj_dir SharpRomans.csproj) --no-build -c $Configuration }
	
	$bin_dir = Join-Path $proj_dir "bin\$Configuration"
	Copy-Item (Join-Path $bin_dir '*.nupkg') -Destination $release_dir
}

task Publish {
	$package_file = Join-Path $release_dir SharpRomans.*.nupkg

	assert(Test-Path $package_file) 'There is no package to push. Please run build.ps1' 
	
	exec { dotnet nuget push (Get-Item $package_file) }
}

task . Pack