# StarSync
A Cross-Platform Save Management App

## About
(**This project is heavily WIP**)

StarSync is an open-source easy to use save management application mainly made for Stardew Valley.<br>
It includes a PHP backend, a functional website written in HTML and CSS, and native clients for Windows and Android written in C# and Java respectively.

## Features
(**Many of the features have only been implemented in the C# client**)
- Modern and Elegant UI (✔️)<br>
- Save Uploading and Downloading (✔️)<br>
- Save Synchronization (✔️)<br>
- Automatic Save Synchronization (✔️)<br>
- Save History Viewing (✔️ - 🔨)<br>
- Save Restoration (❌ - 🔨)
- Save Deletion (✔️)


## Usage
- Clone the repository
- Rename **constants_np.php** to **constants.php**
- Create your database (We plan to include the SQL query to create the DB in the future)
- Fill **constants.php** with your own data
- Upload the files to your webserver
- Edit the **baseURL** string in **Common.cs** (C# Client) so it matches your webserver
- Edit the **baseURL** string in other clients as they become available so it matches your webserver
- Compile the client(s)
- Have fun
