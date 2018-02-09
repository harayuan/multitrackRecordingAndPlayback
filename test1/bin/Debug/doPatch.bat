adb remount
adb push voicepattern\Chinese-Mandarin\* /system/etc/voicecommand/voiceui/uipattern/Chinese-Mandarin/
adb push voicepattern\Chinese-Taiwan\* /system/etc/voicecommand/voiceui/uipattern/Chinese-Taiwan/
adb push voicepattern\English\* /system/etc/voicecommand/voiceui/uipattern/English/
adb push modefile\* /system/etc/voicecommand/voiceui/modefile/
adb push libvoicerecognition.so /system/lib
adb reboot