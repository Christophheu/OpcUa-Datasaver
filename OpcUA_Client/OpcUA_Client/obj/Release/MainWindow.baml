   M S B A M L   `   `   `  ���� G  COpcUA_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:OpcUA_ClientOpcUA_Client      OpcUA_Client.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:OpcUA_Client     -     � Title$'  !OPC Datasaver@Christoph Heuberger��$	��650��$
��1200�� � 
ResizeMode$ NoResize=� � Icon$ Abraham_Automation.ico��
�������
���   � � 	Resources    TrieViewItemStyle �� 
TargetType �� Property �� Value-  'System.Windows.Input.KeyboardNavigation  CheckBoxItemTemplate �� DataType �� ItemsSource	 �� Mode
 �� Orientation d� 	IsChecked  ControlForeground  ControlReadOnlyForeground  ControlDisabledForeground  ControlBackground  ControlHoveredBackground  ControlFocusedBackground  ControlReadOnlyBackground 	 ControlDisabledBackground 
 ControlBorder  ControlHoveredBorder  ControlFocusedBorder  ControlReadOnlyBorder  ControlDisabledBorder  TextBoxTemplateBase �� 
TargetType �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� 	BeginTime g� Duration W� From	 W� To �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value ��Name �� CornerRadius J� Opacity �� Color ��Name �� Triggers P� Property  P� Value  TextBoxBaseStyle! �� BasedOn  ButtonTemplateBase" ��Name  ButtonBaseStyle  ComboBoxToggleButton# � ColumnDefinitions$ F�Name  ComboBoxTextBox  theComboBox% � Cursor& �� 	ClickMode' �� Path( �� RelativeSource) J� IsHitTestVisible* �� SelectionBoxItem+ �� SelectionBoxItemTemplate, ��Name- �� 
IsReadOnly. �� 
IsReadOnly/ �� IsDropDownOpen0 � AllowsTransparency1 J� SnapsToDevicePixels2 � ActualWidth3 �� MaxDropDownHeight4 K� IsItemsHost5   DirectionalNavigation6 �� 
TargetName7 �� Triggers  theComboBoxItem8 �� Padding9 �� TextAlignment�� %�  &	        &	 N     &	 �     &	     &	 !    &	 2    &	 C    &	 V    &	 i    &		 |    &	
 �    &	 �    &	 �    &	 �    &	 �    &	 �    7 	 7  7  7  7  7  7  7  7  7  &	 r    7  7  7 
 7  '�� �    7  &	 �    7 	 7  7  7  7  7  7  7  &	 |    7  7  7 
 7  '�� �    7  &	 �    &	 �    &	 �    7  7  &	 �    �� " Q�.���  �@Q�
IsExpanded .  ��  �@ AcceptsReturn . �� " m� �� *Items+$	 OneTime=�.R��� $
 
Horizontal=�.+��� |�.  
�������$��Center=� �� *	isChecked+�� $	��2,0q����� *name+$	 OneTime=���#fafafc����#383838����#686868����#373737����	#FF098F77����	#FF098F77����	#FF098F77����	#FF098F77����#383838����#373737����#000000����#484848����#787878���� " ��.R�� $
 root��#��z��#��z��   CommonStates��.   
Normal��. �� .��W� $ 00:00:00.000X�$ 00:00:00.500D�$ 1X�$ 0X�$ Opacity�$ hoverBorder��  	MouseOver��. �� .��W� $ 00:00:00.000X�$ 00:00:00.500D�$ 0X�$ 1X�$ Opacity�$ hoverBorder��  Disabled��. �� .���� $ normalBorder��$1 +(Border.Background).(SolidColorBrush.Color)�.g�  $ 0��8   �� $ normalBorder��$2 ,(Border.BorderBrush).(SolidColorBrush.Color)�.g�  $ 0��8    ReadOnly��. �� .���� $ normalBorder��$1 +(Border.Background).(SolidColorBrush.Color)�.g�  $ 0��8  �� $ normalBorder��$2 ,(Border.BorderBrush).(SolidColorBrush.Color)�.g�  $ 0��8    FocusStates��.   Focused��. �� .��W� $ 00:00:00.000X�$ 00:00:00.300D�$ 0X�$ 1X�$ Opacity�$ focusBorder��  	Unfocused��. �� .��W� $ 00:00:00.000X�$ 00:00:00.700D�$ 1X�$ 0X�$ Opacity�$ focusBorder��.+��� $ normalBorder��#��z��#��z��#��z��$ 4���� $ hoverBorder��$ 0Q�$ 4��#��z������ 8  ���� 8  �� $ focusBorder��$ 0Q�$ 4��#��z������ 8  ���� 8  �� $ PART_ContentHost��#��z��$��0q���.  $��2q�#��z��#��z��#��z����Z�  P�  � {�  .  . ���  � �� �� 8  P�  �@��
IsReadOnly  . . ���  � �� �� 8 	 �� " ��.���  � �� �� 8   ��  � �� �� 8  ��  � ��$	 8 4q���  � ��$ Stretch=���  � ��$
 Left=���  � ��$ Stretch=���  � ��$ Center=���  � ��$ 1q���  � �� �� 8  ��  � ��$ 12(���  � ��$ Segoe UI)���  � ��8  �� " ��8!   �� " ��.R�� $
 root��#��z��#��z��   CommonStates��.   
Normal��. �� .��W� $ 00:00:00.000X�$ 00:00:00.500D�$ 1X�$ 0X�$ Opacity�$ hoverBorder��  	MouseOver��. �� .��W� $ 00:00:00.000X�$ 00:00:00.500D�$ 0X�$ 1X�$ Opacity�$ hoverBorder��  Disabled��. �� .���� $ normalBorder��$1 +(Border.Background).(SolidColorBrush.Color)�.g�  $ 0��8   �� $ normalBorder��$2 ,(Border.BorderBrush).(SolidColorBrush.Color)�.g�  $ 0��8    ReadOnly��. �� .���� $ normalBorder��$1 +(Border.Background).(SolidColorBrush.Color)�.g�  $ 0��8  �� $ normalBorder��$2 ,(Border.BorderBrush).(SolidColorBrush.Color)�.g�  $ 0��8  .+��� $ normalBorder��#��z��#��z��#��z��$ 4��._�� .+��� $" MyContentPresenter��#��z��$��Center=�$��Center=�$��0,0,0,0q��� $ hoverBorder��$ 0Q�$ 4��#��z������ 8  ���� 8  ._�� .+��� $" MyContentPresenter1��#��z��$��Center=�$��Center=�$��0,0,0,0q��� $ focusBorder��$ 0Q�$ 4��#��z������ 8  ���� 8  ._�� .+��� $" MyContentPresenter2��#��z��$��Center=�$��Center=�$��0,0,0,0q��� " ��.���  � �� �� 8   ��  � �� �� 8  ��  � ��$	 8 4q���  � ��$ Stretch=���  � ��$
 Left=���  � ��$ Stretch=���  � ��$ Center=���  � ��$ 1q���  � �� �� 8  ��  � ��$ 12(���  � ��$ Segoe UI)���  � ��8  �� " ��8!   �� " d�.���  � �� �� " d�.R�� # �� �� $��30 �.+��� $ Border��$��2��$ 4��#��z�����#373737$��1q�F� $$ Arrow��$��1��#��z��#��z��$��Center=�$��Center=�"����        � 	=  	= � z     	�� " ��.R��� $ PART_ContentHost��|�. �� " ��.���  � �� �#fcfcfa��  � �� �#373737��  � �� �#373737��  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��$ 12(���  � ��$	 150����  � ��$ 35����  � �� �� " ��.R�� .+�d� $��ToggleButton��$
% Hand��#��z��#��z��#��z��8��  $��2��|�.  $& Press=� �� $' IsDropDownOpen�$	 TwoWay=�( �� *TemplatedParent+�� $��ContentSite��) .  #��z* #��z+ #��z��$��	10,3,30,3q�$��Center=�$
��Left=��� $, PART_EditableTextBox��8�� $
��Left=�$��Center=�$��3,3,23,3q�|�. $y�Hidden=�#. z- ��Z� � $��Popup��$��Bottom=�#��z/ 0 . |�.  $��Slide=�.��� $��DropDown��1 . #��z2 #��z3 .+��� $ DropDownBorder��$ 4�����#373737$��1q����#373737�� $��4,6,4,6q�1 . .���� 4 . $5 	Contained=� P�  �@��HasItems  .  . ��� $6 DropDownBorder�� � ��$ 95��P�  �@��
IsGrouping  . . ���  � �� .  P�  �@��
IsEditable  . . ���  � �� .  �� $6 PART_EditableTextBox�� � y�$ Visible=��� $6 ContentSite�� � y�$ Hidden=�7 �� " ��.���  �@J�SnapsToDevicePixels . ��  � ��$ Stretch=���  � ��$ Stretch=���  � ��$ 12(���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��� $��Border��$8 4q�$��2q�$��1,0,0,0q�$ 0�����#373737���#373737._��� $
9 Left=���  P�  �@��IsHighlighted  . . ��� $6 Border�� � �� �#B3CB37�� $6 Border�� � �� �#373737.��� $��0,0,0,1q�.+��� -   : ��Name$: TabControll��$
��Left=�$	��618��$	��Top=�$
��1192��; J� RenderTransformOrigin$; 	0.73,1.02&����	#FF098F77.@��� -   < ��Name$< TabConnection��$��
Verbindung��.��� = J� OpacityMask
= �   � %   OpcUA_Client.ViewModelEndpoints  
_endpoints��%   &	         # �� $	��53* ��� $
��540* �.+��� -   > ��Name$> ButtonShowEndpoints��? � ToolTip$? Endpunktsuche Starten��$��Suche Endpunkte��$
��Left=�$��	20,63,0,0q�$	��Top=�$	��112��$��30��$; 0.5,0.5&�$��2���� -   @ ��Name$@ EndpointsList��#���  $? Endpunkt auswählen��A �� SelectedIndex$A 0��$
��Left=�$��	20,95,0,0q�$	��Top=�$	��953��$��30��B �� 
IsEditableB .  - . C �� Text$C Kein Endpunkt Ausgewählt��$��2������ $' Endpoint.EndpointList�$	 OneWay=��� $��Server URL:��$
��Left=�$��	26,26,0,0q�$	��Top=�$��96��$��30��$��2���� -   $, 
URLTextbox��$3? -Server URL oder Discovery Server URL eingeben��$
��Left=�$��30��$��0,24,0,0q�$,��&opc.tcp://AANB1901.ABRAHAM.local:48020��$	��Top=�$	��867��{�. $
��Bold"�D �� TextWrapping$
D Wrap=�$; 0.385,0.567&�$��1��E �� AutoWordSelectionE . �� -   $> ButtonConnect��$!? Verbindung aufbauen/Trennen��$��	Verbinden��$
��Left=�$��
20,133,0,0q�$	��Top=�$	��112��$��30��$; 0.455,2.467&�$��2���� $��Verbindungsstatus:��$
��Left=�$��
31,133,0,0q�$	��Top=�$	��116��$��30��$��1���� $
��Left=�$	��155��$��	10,15,0,0q�
���   �$	��Top=�$	��977��$��2���� $��Server��$
��Left=�$��20,0,0,0q�$	��Top=�$��47��$��28�����	#FF098F77
= �   �G� -   F G�Name$F PasswordBox��G G� Password$G 1234567��$
��Left=�$��
44,244,0,0q�$	��Top=�$	��171��$��24��$��2���� -	   $, UsernameBox��H �� TextAlignment$
H Left=�$��Username��$
��Left=�$��30��$��
44,272,0,0q�$
D Wrap=�$	��Top=�$	��171��$��2��	� -
   I 	�Name$I RadioButtonAnonym��$
 TrueY�$��Anonym��$
��Left=�$	��Top=�$��
44,204,0,0q�$��2��	� -   $I RadioButtonPassword��$��Passwort verwenden��$
��Left=�$��
44,224,0,0q�$	��Top=�$��2���� $
��Left=�$	��126��$��
10,187,0,0q�
���   �$	��Top=�$	��243��$��2���� $��Authentifizierung�����	#FF098F77$
��Left=�$��
26,173,0,0q�$	��Top=�$��2���� $��1��$
��Left=�$	��152��$��917,428,0,0q�$	��Top=�$	��153��$��Abraham_Logo.png���� -   J ��Name$J ConntectedImg��$$��connected-icon-3-00ff00-32.png��$��1��$��152,133,896,425q�$��32��$��32���� -   $J DisconnectedImg��$
��Left=�$��32��$	��Top=�$��32��$(��"disconnected-icon-15-fa8072-32.png��$��1��$��152,133,0,0q��� -   $< TabData��$��Serverdaten��.��� -   $ TabDataGrid�����	#FF098F77$; 
0.373,0.71&�.+�R� -   K R�Name$K OPCDataTreeView��$
��Left=�$	��580��$	��Top=�$	��415��#��[  #��[ L � ContextMenuL �� .@�m� -   $��Details Anzeigen��m� -   $��Baum aktualisieren��m� -   $ ��Einzelvariablen Einbrowsen���� -   M ��Name$M ShowData��N J� 	AllowDropN . $
��Left=�$	��352��$��
420,27,0,0q�$	��Top=�$	��756������ $' GetObversableDictionary�$	 OneWay=��� -   O ��Name$O BrowseStructs��$(��"Arrays als Einzelvariablen Browsen��$
��Left=�$��564,560,0,0q�$	��Top=��� -   $��Daten Browsen��$
��Left=�$��422,551,0,0q�$	��Top=�$��30��$	��102���� -   $��Liste Leeren��$? Beobachtungsliste leeren��$
��Left=�$��420,384,0,0q�$	��Top=�$��30��$	��102���� $U��OZiehen Sie die Variablen per Drag and Drop in das Textfeld um sie zu Beobachten��$��420,0,324,564q�$��26���� -   $!��Aktualwerte Speichern Unter��$6? 0Aktualwerte der beobachteten Variablen speichern��$
��Left=�$��527,384,0,0q�$	��Top=�$��30��$	��162���� -   $��Beobachtungsliste Öffnen��$+? %Variablenliste zum beobachten Öffnen��$
��Left=�$��694,384,0,0q�$	��Top=�$��30��$	��147���� -   $&�� Angewählte Variablen Beobachten��$3? -Im Datenbaum angewählte Variablen beobachten��$
��Left=�$��846,384,0,0q�$	��Top=�$��30��$	��193��$; 	0.492,0.5&��� -   $��Werte sichern��$2? ,Im Datenbaum angewählte Variablen speichern��$
��Left=�$��420,474,0,0q�$	��Top=�$	��102��$; 	0.492,0.5&�$��30���� -   $��Werte schreiben��$#? Variablen aus Datei schreiben��$
��Left=�$��527,474,0,0q�$	��Top=�$	��102��$; 	0.492,0.5&�$��30���� $
��Left=�$	��152��$��1023,428,0,0q�$	��Top=�$	��153��$��Abraham_Logo.png��