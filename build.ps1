[CmdletBinding()]
Param(
	[string]$Task,
	[ValidateSet('Debug', 'Release')]
	[string]$Configuration = 'Release'
)

function Main () {
	$script_directory = Split-Path -parent $PSCommandPath   
	$base_dir  = resolve-path $script_directory
	$tools_dir = Join-Path $base_dir tools

	$tool_dir = Get-ChildItem (Join-Path $tools_dir *) -Directory | where {$_.Name.StartsWith('Invoke-Build')}
	# get first directory
	$tool_dir = $tool_dir[0]

	& $tool_dir\tools\Invoke-Build.ps1 $Task -Configuration $configuration
}
Main