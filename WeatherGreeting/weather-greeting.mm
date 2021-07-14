<map version="freeplane 1.9.0">
<!--To view this file, download free mind mapping software Freeplane from http://freeplane.sourceforge.net -->
<node TEXT="weather-greeting" FOLDED="false" ID="ID_1944192918" CREATED="1624284418801" MODIFIED="1626207827896" STYLE="oval">
<font NAME="JetBrains Mono" SIZE="18"/>
<hook NAME="MapStyle" background="#3c3f41" zoom="1.948">
    <properties fit_to_viewport="false" edgeColorConfiguration="#808080ff,#00ddddff,#dddd00ff,#dd0000ff,#00dd00ff,#dd0000ff,#7cddddff,#dddd7cff,#dd7cddff,#7cdd7cff,#dd7c7cff,#7c7cddff"/>

<map_styles>
<stylenode LOCALIZED_TEXT="styles.root_node" STYLE="oval" UNIFORM_SHAPE="true" VGAP_QUANTITY="24 pt">
<font SIZE="24"/>
<stylenode LOCALIZED_TEXT="styles.predefined" POSITION="right" STYLE="bubble">
<stylenode LOCALIZED_TEXT="default" ID="ID_348524716" ICON_SIZE="12 pt" COLOR="#cccccc" STYLE="fork">
<arrowlink SHAPE="CUBIC_CURVE" COLOR="#000000" WIDTH="2" TRANSPARENCY="200" DASH="" FONT_SIZE="9" FONT_FAMILY="SansSerif" DESTINATION="ID_348524716" STARTARROW="NONE" ENDARROW="DEFAULT"/>
<font NAME="SansSerif" SIZE="10" BOLD="false" ITALIC="false"/>
</stylenode>
<stylenode LOCALIZED_TEXT="defaultstyle.details"/>
<stylenode LOCALIZED_TEXT="defaultstyle.attributes">
<font SIZE="9"/>
</stylenode>
<stylenode LOCALIZED_TEXT="defaultstyle.note" COLOR="#cccccc" BACKGROUND_COLOR="#3c3f41" TEXT_ALIGN="LEFT"/>
<stylenode LOCALIZED_TEXT="defaultstyle.floating">
<edge STYLE="hide_edge"/>
<cloud COLOR="#f0f0f0" SHAPE="ROUND_RECT"/>
<richcontent CONTENT-TYPE="plain/auto" TYPE="DETAILS"/>
<richcontent TYPE="NOTE" CONTENT-TYPE="plain/auto"/>
</stylenode>
<stylenode LOCALIZED_TEXT="defaultstyle.selection" BACKGROUND_COLOR="#3c3c57" STYLE="bubble" BORDER_COLOR_LIKE_EDGE="false" BORDER_COLOR="#002080"/>
</stylenode>
<stylenode LOCALIZED_TEXT="styles.user-defined" POSITION="right" STYLE="bubble">
<stylenode LOCALIZED_TEXT="styles.topic" COLOR="#18898b" STYLE="fork">
<font NAME="Liberation Sans" SIZE="10" BOLD="true"/>
</stylenode>
<stylenode LOCALIZED_TEXT="styles.subtopic" COLOR="#cc3300" STYLE="fork">
<font NAME="Liberation Sans" SIZE="10" BOLD="true"/>
</stylenode>
<stylenode LOCALIZED_TEXT="styles.subsubtopic" COLOR="#669900">
<font NAME="Liberation Sans" SIZE="10" BOLD="true"/>
</stylenode>
<stylenode LOCALIZED_TEXT="styles.important">
<icon BUILTIN="yes"/>
</stylenode>
</stylenode>
<stylenode LOCALIZED_TEXT="styles.AutomaticLayout" POSITION="right" STYLE="bubble">
<stylenode LOCALIZED_TEXT="AutomaticLayout.level.root" COLOR="#dddddd" STYLE="oval" SHAPE_HORIZONTAL_MARGIN="10 pt" SHAPE_VERTICAL_MARGIN="10 pt">
<font SIZE="18"/>
</stylenode>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,1" COLOR="#ff3300">
<font SIZE="16"/>
</stylenode>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,2" COLOR="#ffb439">
<font SIZE="14"/>
</stylenode>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,3" COLOR="#99ffff">
<font SIZE="12"/>
</stylenode>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,4" COLOR="#bbbbbb">
<font SIZE="10"/>
</stylenode>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,5"/>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,6"/>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,7"/>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,8"/>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,9"/>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,10"/>
<stylenode LOCALIZED_TEXT="AutomaticLayout.level,11"/>
</stylenode>
</stylenode>
</map_styles>
</hook>
<hook NAME="AutomaticEdgeColor" COUNTER="4" RULE="ON_BRANCH_CREATION"/>
<node TEXT="testing considerations" POSITION="right" ID="ID_1037823899" CREATED="1624283231202" MODIFIED="1624284498723">
<edge COLOR="#dddd00"/>
<node TEXT="WeatherData" ID="ID_109432244" CREATED="1626207875533" MODIFIED="1626207887854">
<node TEXT="TimeOfDay" ID="ID_1618870613" CREATED="1626207889899" MODIFIED="1626207902702">
<node TEXT="Morning" ID="ID_1064226738" CREATED="1626207904163" MODIFIED="1626207910910"/>
<node TEXT="After noon" ID="ID_1327261336" CREATED="1626207911532" MODIFIED="1626207933134"/>
<node TEXT="Evening" ID="ID_1249843223" CREATED="1626207933524" MODIFIED="1626207946822"/>
</node>
<node TEXT="Temperature" ID="ID_689165407" CREATED="1626207950381" MODIFIED="1626207975502">
<node TEXT="Cold" ID="ID_1342568337" CREATED="1626207976788" MODIFIED="1626207981949"/>
<node TEXT="Cool" ID="ID_468387370" CREATED="1626207982564" MODIFIED="1626208004149"/>
<node TEXT="Warm" ID="ID_1445350410" CREATED="1626208004588" MODIFIED="1626208007925"/>
<node TEXT="Hot" ID="ID_880773127" CREATED="1626208008228" MODIFIED="1626208011205"/>
</node>
<node TEXT="UvIndex" ID="ID_905138351" CREATED="1626208021996" MODIFIED="1626208036413">
<node TEXT="Low" ID="ID_1197283936" CREATED="1626208038140" MODIFIED="1626208062365"/>
<node TEXT="Medium" ID="ID_521922844" CREATED="1626208062692" MODIFIED="1626208065693"/>
<node TEXT="High" ID="ID_48359416" CREATED="1626208066076" MODIFIED="1626208069126"/>
</node>
</node>
</node>
<node TEXT="Scenarios" POSITION="right" ID="ID_1575433986" CREATED="1624283568441" MODIFIED="1624284561072" HGAP_QUANTITY="13.25 pt" VSHIFT_QUANTITY="24.75 pt">
<edge COLOR="#00dd00"/>
<node TEXT="TimeOfDay" ID="ID_729975703" CREATED="1626207889899" MODIFIED="1626207902702">
<node TEXT="Morning" ID="ID_1362757631" CREATED="1626207904163" MODIFIED="1626207910910">
<node TEXT="Temperature" ID="ID_1019585398" CREATED="1626207950381" MODIFIED="1626207975502">
<node TEXT="Warm" ID="ID_1495455992" CREATED="1626208004588" MODIFIED="1626208007925">
<node TEXT="UvIndex" ID="ID_1832799755" CREATED="1626208021996" MODIFIED="1626208036413">
<node TEXT="Low" ID="ID_1961772201" CREATED="1626208038140" MODIFIED="1626273341692">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="Medium" ID="ID_466906303" CREATED="1626208062692" MODIFIED="1626273341693">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="High" ID="ID_1585966166" CREATED="1626208066076" MODIFIED="1626273341693">
<icon BUILTIN="button_ok"/>
</node>
</node>
</node>
<node TEXT="Hot" ID="ID_1271313009" CREATED="1626208008228" MODIFIED="1626208011205">
<node TEXT="UvIndex" ID="ID_1409061791" CREATED="1626208021996" MODIFIED="1626208036413">
<node TEXT="Low" ID="ID_627161639" CREATED="1626208038140" MODIFIED="1626273244144">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="Medium" ID="ID_184540442" CREATED="1626208062692" MODIFIED="1626273239576">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="High" ID="ID_1995845458" CREATED="1626208066076" MODIFIED="1626272976330">
<icon BUILTIN="button_ok"/>
</node>
</node>
</node>
</node>
</node>
<node TEXT="After noon" ID="ID_1982330250" CREATED="1626207911532" MODIFIED="1626207933134">
<node TEXT="Temperature" ID="ID_420837218" CREATED="1626207950381" MODIFIED="1626207975502">
<node TEXT="Warm" ID="ID_659747410" CREATED="1626208004588" MODIFIED="1626208007925">
<node TEXT="UvIndex" ID="ID_1167492534" CREATED="1626208021996" MODIFIED="1626208036413">
<node TEXT="Low" ID="ID_610540549" CREATED="1626208038140" MODIFIED="1626273994459">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="Medium" ID="ID_1148996313" CREATED="1626208062692" MODIFIED="1626273994459">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="High" ID="ID_1099362841" CREATED="1626208066076" MODIFIED="1626273994459">
<icon BUILTIN="button_ok"/>
</node>
</node>
</node>
<node TEXT="Hot" ID="ID_820513263" CREATED="1626208008228" MODIFIED="1626208011205">
<node TEXT="UvIndex" ID="ID_1117752933" CREATED="1626208021996" MODIFIED="1626208036413">
<node TEXT="Low" ID="ID_7629189" CREATED="1626208038140" MODIFIED="1626273994460">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="Medium" ID="ID_342102531" CREATED="1626208062692" MODIFIED="1626273994460">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="High" ID="ID_1670961453" CREATED="1626208066076" MODIFIED="1626273994460">
<icon BUILTIN="button_ok"/>
</node>
</node>
</node>
</node>
</node>
<node TEXT="Evening" ID="ID_1675192852" CREATED="1626207933524" MODIFIED="1626207946822">
<node TEXT="Temperature" ID="ID_943146877" CREATED="1626207950381" MODIFIED="1626207975502">
<node TEXT="Warm" ID="ID_1323256141" CREATED="1626208004588" MODIFIED="1626208007925">
<node TEXT="UvIndex" ID="ID_1596093592" CREATED="1626208021996" MODIFIED="1626208036413">
<node TEXT="Low" ID="ID_1471392666" CREATED="1626208038140" MODIFIED="1626273994460">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="Medium" ID="ID_413341636" CREATED="1626208062692" MODIFIED="1626273994460">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="High" ID="ID_1932245791" CREATED="1626208066076" MODIFIED="1626273994460">
<icon BUILTIN="button_ok"/>
</node>
</node>
</node>
<node TEXT="Hot" ID="ID_1886094974" CREATED="1626208008228" MODIFIED="1626208011205">
<node TEXT="UvIndex" ID="ID_1197300044" CREATED="1626208021996" MODIFIED="1626208036413">
<node TEXT="Low" ID="ID_1225246895" CREATED="1626208038140" MODIFIED="1626273994460">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="Medium" ID="ID_1114627616" CREATED="1626208062692" MODIFIED="1626273994460">
<icon BUILTIN="button_ok"/>
</node>
<node TEXT="High" ID="ID_485462842" CREATED="1626208066076" MODIFIED="1626273994460">
<icon BUILTIN="button_ok"/>
</node>
</node>
</node>
</node>
</node>
</node>
</node>
</node>
</map>
