# UtilityMonitorForWindows


The UtilityMonitor is small program that runs and verify if a specific process is up and running.
If the process is running, you can close it, by specifing the name, **lifetime** (of the process) and **frequence** (used by the program to verify the process again).

The solution is split in 2 small projects:
1. The Project for the program
2. NUnit Test Project

Set-up: You can run the program using CMD/ Developer PowerShall: **dotnet run notepad 1 1**  (Eg) -> notepad 1 1 (name, lifetime, frequence) are the arguments for this to work.
The program should be stopped by pressing "Q" button from keyboard.

The output should be similar with:

  _Done for searching processes. Retrying in 1 minutes_ 
  _Done for searching processes. Retrying in 1 minutes_
  _Successfully closed the process: 24856, Notepad_
  _Done for searching processes. Retrying in 1 minutes_
  _Exit the program_

The Unit Test are attached to this file.

![NUnitTests](https://github.com/IustinDragan/UtilityMonitorForWindows/assets/88083009/0df6f07c-65ac-4ecc-8e69-398b22bc3404)
![ConsoleResponse_v2](https://github.com/IustinDragan/UtilityMonitorForWindows/assets/88083009/2758a810-3565-4349-9384-03d1f4bda7a1)
