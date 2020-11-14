SET ROOT=%~dp0%.
SET NUGET_PATH=%ROOT%\tools\nuget.exe
SET VISUALSTUDIO_PATH=%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Enterprise
SET MSBUILD_PATH=%VISUALSTUDIO_PATH%\MSBuild\Current\Bin\MSBuild.exe
SET NUNIT_PATH=%ROOT%\packages\NUnit.ConsoleRunner.3.12.0-beta1\tools\nunit3-console.exe

"%NUGET_PATH%" restore "FilterAndRank.sln"

"%MSBUILD_PATH%" "FilterAndRank.sln" /nologo /verbosity:minimal /p:Configuration=Release /t:Clean;Build

"%NUNIT_PATH%" "%ROOT%\source\FilterAndRank.Console.UnitTest\bin\Release\FilterAndRank.Console.UnitTest.dll"
