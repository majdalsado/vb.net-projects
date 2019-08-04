@echo off
echo MineMod Installer // Mod Adder
color 1A

SET LOCATION=%appdata%\.minecraft\bin\minecraft.jar
7za a -tzip -y %LOCATION% "C:\Temp\MineMod\TempMod\*"