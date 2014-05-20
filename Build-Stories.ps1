param(
	[Parameter(Mandatory=$True)]
	$storyPath,
	$xslFile = 'StoryQ-md.xslt',
    $targetFile
	)

$xslt = New-Object System.Xml.Xsl.XslCompiledTransform
$scriptDirectory = Split-Path -parent $PSCommandPath
$xslFile = Join-Path $scriptDirectory $xslFile

$xslt.Load($xslFile)

$output = New-Object System.IO.MemoryStream
$reader = new-object System.IO.StreamReader($output)

$storyPath = Resolve-Path $storyPath
$xslt.Transform($storyPath,$null, $output)

$output.position = 0    
$transformed = [string]$reader.ReadToEnd()

$transformed.Replace("  ", "")  | Out-File -filepath $targetFile
