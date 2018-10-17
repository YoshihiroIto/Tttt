echo off
cd /d %~dp0

rd /S /Q source\docfx_project\obj

pushd source\docfx_project

..\..\external\docfx\docfx metadata
..\..\external\docfx\docfx build

popd

