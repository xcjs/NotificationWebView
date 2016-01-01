!include "MUI2.nsh"
!include "x64.nsh"

;--------------------------------
;General

  ;Name and file
  Name "NotificationWebView Installer"
  OutFile "NotificationWebView_x64_Setup.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES64\XCJS\NotificationWebView"
  
  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\NotificationWebView" ""

  ;Request application privileges for Windows Vista
  RequestExecutionLevel admin

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_LICENSE "${NSISDIR}\Docs\Modern UI\License.txt"
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
  
	;ADD YOUR OWN FILES HERE...
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
  ;WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  ;LangString DESC_SecDummy ${LANG_ENGLISH} "A test section."

  ;Assign language strings to sections
  ;!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
	;!insertmacro MUI_DESCRIPTION_TEXT ${SecDummy} $(DESC_SecDummy)
  ;!insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

;Section "Uninstall"

  ;Delete "$INSTDIR\Uninstall.exe"

  ;RMDir "$INSTDIR"

  ;DeleteRegKey /ifempty HKCU "Software\Modern UI Test"

;SectionEnd
