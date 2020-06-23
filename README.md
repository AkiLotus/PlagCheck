# PlagCheck
[Network Programming institute project] A client-server program to detect plagiarized source code from students in programming problems / exams.

# System requirements
- Windows 7 or above.
- .NET Framework 4.7.2.
- MySQL 8.0 for server-side.

# Overview
This application is splitted into two segments, a server interface and a client interface.

You can either fork the source code and modify it yourself for customization, or simply install the releases [here](https://github.com/NTI-Akikaze/PlagCheck/releases).

It uses the open-source project [JPlag](https://github.com/jplag/jplag) as the analyzing core to calculate the similarity between selected source codes.

# Installation instructions
1. Server-side

- Download the server archive from the [release site](https://github.com/NTI-Akikaze/PlagCheck/releases).
- If not installed, [install MySQL 8.0](https://dev.mysql.com/downloads/windows/installer/8.0.html).
- Configure the MySQL server such as:
  - The password for the "root" user is "root" (as stated in PlagCheck_Server/DAO.cs).
  - The localhost instance (localhost:3306) should be online, and has a schema named "plagcheck" (as stated in PlagCheck_Server/DAO.cs).
  - If you want to use another database server password or schema name, edit in the source code and build a seperate server-side solution (Visual Studio 2019 required).
- Import the content from the [schema file](https://gist.github.com/NTI-Akikaze/189e938f79065cd954c66d8db0d0786f) to initialize the schema. This will create all the needed table, along with a few example problems and solutions.
- Extract the archive, and run the "setup.exe" file from the decompressed folder.

2. Client-side

- Download the client archive from the [release site](https://github.com/NTI-Akikaze/PlagCheck/releases).
- Extract the archive, and run the "setup.exe" file from the decompressed folder.

# Usage instructions
1. Server-side

- Initialize the server by inputting an integer as port number (most preferably being between 1024 and 65535), then click the "Start" button.
- Click the "Set JPlag location" button, and browse for the JPlag binary release you wanted to use, most preferably [v2.11.8](https://github.com/jplag/jplag/releases/tag/v2.11.8-SNAPSHOT) for this project. If the binary is not yet available, you have to [download](https://github.com/jplag/jplag/releases/tag/v2.11.8-SNAPSHOT) it first.
- On the tab "Problems Manager", you can either:
  - Add a new problem by clicking the "Add a new problem" button.
  - Edit an existing problem by clicking the "Edit" button on the problem's respective line on the table.
  - Delete an existing problem by clicking the "Delete" button on the problem's respective line on the table.
  - A problem contains a name, and its time limit (in seconds) and memory limit (in MBs). The two latter attributes are purely cosmetics if this application is standing alone, i.e. not yet integrated with a judge system.
- On the tab "Solutions Manager", you can either:
  - Add a new solution by clicking the "Add a new solution" button.
  - View a solution by: first, choosing the associated problem from the "Problem" combobox, then choosing the wanted solution from the "Solution" combobox. The current release lacks source code markup (however the font inside the source code viewer is still monospace).
  - Edit the viewing solution by clicking the "Edit solution" button.
  - Delete the viewing solution by clicking the "Delete solution" button.
  - A solution contains its language and the solution's actual raw text content.
- As long as the server is kept online, it can automatically accepts requests from clients. You can see it from the status box at the bottom, or view more details by clicking at the "View logs" button (the "View logs" button feature is currently not yet complete, it still looks a little bit clustered).
- If you want to turn off the server, click the "Stop" button.

2. Client-side

- Initialize the client by inputting the server's IP and port number, then click the "Connect" button. You can ask the server's administrator for the information. The server side can see these infos as the first status line right after they initialize the server (as the form of "Successfully opened socket at aaa.bbb.ccc.ddd:eeeee.").
- Choose the problem from the "Problem" combobox, and the language from the "Language" combobox.
- Click the "Choose folder", browse for the folder containing the solutions you want to check for plagiarism. Based on the chosen language, the application will automatically filtering the suitable files based on the file extensions.
- You can choose which solutions are to be checked by checking the "Chosen" boxes. Initially, all boxes are checked, i.e. all solutions are going to be checked by default.
- Click on either "Internal Check" or "Global Check" to ask the server to perform the analysis. With "Internal Check", only the chosen solutions are considered, while "Global Check" includes the solutions being stored internally in the server-side's database.
- Regardless of the type of check, they will all be responded by a result form, with a list of solutions, sorted descendingly by the most similar match with each solution.
  - Click on the solution (the first column) to view the solution alone.
  - Click on the similar case (the cell having the compared solution and the similarity rate) to view both solutions parallelly.
  - If a solution is worth included into the server for future use, click the "Add" button on its respective line.
- If you want to terminate the connection, click the "Disconnect" button.
