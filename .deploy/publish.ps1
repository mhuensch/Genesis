Param (
    $variables = @{},   
    $artifacts = @{},
    $scriptPath,
    $buildFolder,
    $srcFolder,
    $outFolder,
    $tempFolder,
    $projectName,
    $projectVersion,
    $projectBuildNumber
)

Write-Output "Publishing NuGet package"
Write-Output "Source: $(srcFolder)"
Write-Output "Source: $srcFolder"