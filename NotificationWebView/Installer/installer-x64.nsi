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
	InstallDirRegKey HKCU "Software\NotificationWebView" ""

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
  
	File /r "..\bin\x64\Release\locales"
	File "..\bin\x64\Release\NotificationWebView.exe"
	File "..\bin\x64\Release\NotificationWebView.exe.config"
	File "..\bin\x64\Release\CefSharp.BrowserSubprocess.exe"
	File "..\bin\x64\Release\*.dll"
	File "..\bin\x64\Release\*.bin"
	File "..\bin\x64\Release\*.pak"
	File "..\bin\x64\Release\*.dat"	

	;Store installation folder
	;WriteRegStr HKCU "Software\NotificationWebView" "" $INSTDIR
  
	;Create uninstaller
	WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

;--------------------------------
;Uninstaller Section

Section "Uninstall"

	Delete "$INSTDIR\Uninstall.exe"

	RMDir "$INSTDIR"

	DeleteRegKey /ifempty HKCU "Software\NotificationWebView"

SectionEnd
