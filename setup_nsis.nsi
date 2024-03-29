; Script generated by the HM NIS Edit Script Wizard.
 
Function .onInit
  SetOutPath $TEMP
  File /oname=spltmp.bmp "splash.bmp"

; optional
; File /oname=spltmp.wav "my_splashshit.wav"

  advsplash::show 1000 600 400 -1 $TEMP\spltmp

  Pop $0 ; $0 has '1' if the user closed the splash screen early,
         ; '0' if everything closed normally, and '-1' if some error occurred.

  Delete $TEMP\spltmp.bmp
;  Delete $TEMP\spltmp.wav
FunctionEnd

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "VCT"
!define PRODUCT_VERSION "1.9.7.1"
!define PRODUCT_PUBLISHER "Zlatko Babic"
!define PRODUCT_WEB_SITE "https://sourceforge.net/projects/videoconvertertranscoder/?source=directory"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\VCT.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

; MUI 1.67 compatible ------
!include "MUI.nsh"

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "Hadezign-Hobbies-Movies.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; License page
!insertmacro MUI_PAGE_LICENSE "copying.txt"
; Directory page
!insertmacro MUI_PAGE_DIRECTORY
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; Finish page
;!define MUI_FINISHPAGE_RUN "$INSTDIR\VCT.exe"
;!define MUI_FINISHPAGE_SHOWREADME "$INSTDIR\README.txt"
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES

; Language files
!insertmacro MUI_LANGUAGE "English"

; MUI end ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "VCT_setup.exe"
InstallDir "$PROGRAMFILES\VCT"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

Section "MainSection" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "bin\Release\VCT.exe"
  CreateDirectory "$SMPROGRAMS\VCT"
  CreateShortCut "$SMPROGRAMS\VCT\VCT.lnk" "$INSTDIR\VCT.exe"
  CreateShortCut "$DESKTOP\VCT.lnk" "$INSTDIR\VCT.exe"
  File "ffmpeg.exe"
  File "ffprobe.exe"
  File "ffplay.exe"
  File "Newtonsoft.Json.dll"
  File "VCT_help.pdf"
  CreateDirectory "$PROGRAMFILES\VCT"
  CreateShortCut "$SMPROGRAMS\VCT\Help.lnk" "$INSTDIR\VCT_help.pdf"
  File "copying.txt"
  File "README.md"
  SectionEnd

Section -AdditionalIcons
  CreateShortCut "$SMPROGRAMS\VCT\Uninstall.lnk" "$INSTDIR\uninst.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\VCT.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\VCT.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd


Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) was successfully removed from your computer."
FunctionEnd

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "Are you sure you want to completely remove $(^Name) and all of its components?" IDYES +2
  Abort
FunctionEnd

Section Uninstall
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\README.md"
  Delete "$INSTDIR\copying.txt"
  Delete "$INSTDIR\VCT_help.pdf"
  Delete "$INSTDIR\ffmpeg.exe"
  Delete "$INSTDIR\ffprobe.exe"
  Delete "$INSTDIR\ffplay.exe"
  Delete "$INSTDIR\Newtonsoft.Json.dll"
  Delete "$INSTDIR\VCT.exe"
  
  Delete "$SMPROGRAMS\VCT\Uninstall.lnk"
  Delete "$$SMPROGRAMS\VCT\Help.lnk"
  Delete "$DESKTOP\VCT.lnk"
  Delete "$SMPROGRAMS\VCT\VCT.lnk"

  RMDir "$SMPROGRAMS\VCT"
  RMDir "$INSTDIR"
  RMDir ""

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd