<img src="https://raw.githubusercontent.com/xcjs/NotificationWebView/master/NotificationWebView/Assets/iconsineed-world-128-filled.png" alt="NotificationWebView Logo" style="float: left; margin-right: 1rem; width: 48px; height: 48px;">
# NotificationWebView
Chromium web view displayable from the Windows notification area.

## Building

1. Download and install [Visual Studio 2015 Community Edition](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx) 
2. Clone the [repository](https://github.com/xcjs/NotificationWebView.git)
3. Open the solution using the NotificationWebView.sln file
4. Select the "Release" build configuration
5. Select your platform (x86 or x64) from the next dropdown
6. Find the "Build" menu and select "Build Solution"

## Creating the Installer

The installer is created using NSIS. Adding makensis to your PATH is recommended, but not required.

1. Install [NSIS 2.x](http://nsis.sourceforge.net/Main_Page)
2. Open a Command Prompt to the Installer directory under the NotificationWebView project
3. Execute `makensis installer-x64.nsi`

## First-Time Run

NotificationWebView will open in the notification area and will not display in the normal
taskbar area. It may be necessary to check the condensed notification area icon list if
the NotificationWebView icon is not visible at first. 

Once located, the icon can be dragged out with the rest of the notification area icons.
