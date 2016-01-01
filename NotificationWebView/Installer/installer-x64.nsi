!include "MUI2.nsh"
!include "x64.nsh"

;--------------------------------
;General

	;Name and file
	Name "NotificationWebView"
	OutFile "NotificationWebView_x64_Setup.exe"

	;Default installation folder
	InstallDir "$PROGRAMFILES64\XCJS\NotificationWebView"
  
	;Get installation folder from registry if available
	InstallDirRegKey HKLM "Software\NotificationWebView" ""

	;Request application privileges for Windows UAC
	RequestExecutionLevel admin

;--------------------------------
;Interface Settings

	!define MUI_ABORTWARNING
	!define MUI_ICON "..\Assets\iconsineed-world-128-filled.ico"

;--------------------------------
;Pages

	!insertmacro MUI_PAGE_LICENSE "..\..\LICENSE"
	!insertmacro MUI_PAGE_COMPONENTS
	!insertmacro MUI_PAGE_DIRECTORY
	!insertmacro MUI_PAGE_INSTFILES
  
	!insertmacro MUI_UNPAGE_CONFIRM
	!insertmacro MUI_UNPAGE_INSTFILES

;--------------------------------
;Languages
 
	!insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "NotificationWebView" NotificationWebView

	SetOutPath "$INSTDIR"
  
	File /r "..\bin\x64\Release\Assets"
	File /r "..\bin\x64\Release\locales"
	File "..\bin\x64\Release\NotificationWebView.exe"
	File "..\bin\x64\Release\NotificationWebView.exe.config"
	File "..\bin\x64\Release\CefSharp.BrowserSubprocess.exe"
	File "..\bin\x64\Release\*.dll"
	File "..\bin\x64\Release\*.bin"
	File "..\bin\x64\Release\*.pak"
	File "..\bin\x64\Release\*.dat"

	;Store installation folder
	WriteRegStr HKCU "Software\NotificationWebView" "" $INSTDIR
  
	;Create uninstaller
	WriteUninstaller "$INSTDIR\Uninstall.exe"

	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NotificationWebView" "DisplayName" "NotificationWebView"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NotificationWebView" "DisplayIcon" "$INSTDIR\NotificationWebView.exe"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NotificationWebView" "UninstallString" "$\"$INSTDIR\Uninstall.exe$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NotificationWebView" "NoModify" 1
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NotificationWebView" "NoRepair" 1

SectionEnd

Section "Start Menu Shortcuts" StartMenu
	createDirectory "$SMPROGRAMS\XCJS"
	createShortCut "$SMPROGRAMS\XCJS\NotificationWebView.lnk" "$INSTDIR\NotificationWebView.exe"
	createShortCut "$SMPROGRAMS\XCJS\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
SectionEnd

Section "Desktop Shortcut" Desktop
	createShortcut "$Desktop\NotificationWebView.lnk" "$INSTDIR\NotificationWebView.exe" "" "$INSTDIR\Assets\iconsineed-world-128-filled.ico"
SectionEnd

;--------------------------------
;Uninstaller Section

Section "Uninstall"

	RMDir /r "$SMPROGRAMS\XCJS"
	RMDir /r "$INSTDIR"
	Delete "$Desktop\NotificationWebView.lnk"

	DeleteRegKey HKLM "Software\NotificationWebView"
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NotificationWebView"

SectionEnd
