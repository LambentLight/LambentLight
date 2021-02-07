!include "MUI2.nsh"

!define MUI_ICON "icon.ico" 
!define MUI_UNICON "icon.ico"

Name "LambentLight"
OutFile "dist\LambentLightInstaller.exe"
Unicode True
InstallDir "$PROGRAMFILES64\LambentLight"
InstallDirRegKey HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\LambentLight" "InstallLocation"
RequestExecutionLevel admin

!define MUI_FINISHPAGE_NOAUTOCLOSE ; Press Continue instead of finishing inmediately
!define MUI_ABORTWARNING ; Show a Warning when aborting the install

; Pages
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "LICENSE"
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

!insertmacro MUI_LANGUAGE "English"

Section "Server" Server
    SetOutPath "$INSTDIR"
    File "dist\lambentlightd.exe"
SectionEnd

Section "Uninstaller" Uninstaller
    SectionIn RO
    SetOutPath "$INSTDIR"
    File "icon.ico"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\LambentLight" "" ""
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\LambentLight" "DisplayName" "LambentLight"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\LambentLight" "Publisher" "Hannele 'Lemon' Ruiz"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\LambentLight" "URLInfoAbout" "https://discord.gg/Cf6sspj"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\LambentLight" "HelpLink" "https://justalemon.ml/LambentLight"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\LambentLight" "InstallLocation" "$INSTDIR"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\LambentLight" "UninstallString" "$INSTDIR\uninstall.exe"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\LambentLight" "QuietUninstallString" "$INSTDIR\uninstall.exe /S"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\LambentLight" "DisplayIcon" "$INSTDIR\icon.ico"
    WriteUninstaller "$INSTDIR\uninstall.exe"
SectionEnd

Section "Uninstall"
    RMDir /r "$INSTDIR"
    DeleteRegKey HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\LambentLight"
SectionEnd

LangString DESC_Server ${LANG_ENGLISH} "Installs the Server component. It allows you to host your own CFX Server Instances."
LangString DESC_Uninstaller ${LANG_ENGLISH} "Creates Uninstall information to remove the program from Apps and Features."
!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
!insertmacro MUI_DESCRIPTION_TEXT ${Server} $(DESC_Server)
!insertmacro MUI_DESCRIPTION_TEXT ${Uninstaller} $(DESC_Uninstaller)
!insertmacro MUI_FUNCTION_DESCRIPTION_END
