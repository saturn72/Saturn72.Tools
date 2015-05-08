<xsl:stylesheet
      xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
      version="1.0">
  <xsl:output method="xml" />
  <xsl:template match="/">
    <xml>
      <xsl:for-each select="datafeed/Item">
        <codes>
          <mpn>
            <xsl:value-of select="Full_Number"/>
          </mpn>
          <upc>
            <xsl:value-of select="UPC"/>
          </upc>
          <hts>
            <xsl:value-of select="HTS_Code"/>
          </hts>
          <nafta>
            <xsl:value-of select="Nafta_Code"/>
          </nafta>
        </codes>
        <name>
          <xsl:value-of select="Description"/>
        </name>
        <short_description/>
        <full_description>
          <xsl:value-of select="Long_Description"/>
        </full_description>
        <brands>
          <brand>
            <xsl:value-of select="Brand"/>
          </brand>
        </brands>
        <media>
          <images>
            <image>
              <xsl:attribute name="is_primary">
                <xsl:value-of select="true()"/>
              </xsl:attribute>
              <thumbnail_small>
                <xsl:value-of select="Image_Link_Sm"/>
              </thumbnail_small>
              <thumbnail_medium>
                <xsl:value-of select="Image_Link_TN_5_0"/>
              </thumbnail_medium>
              <medium>
                <xsl:value-of select="Image_Link_Consumer"/>
              </medium>
              <large>
                <xsl:value-of select="Image_Link_Large"/>
              </large>
              <tiff>
                <xsl:value-of select="Image_Link_Tiff"/>
              </tiff>
            </image>
            <image>
              <xsl:attribute name="is_primary">
                <xsl:value-of select="false()"/>
              </xsl:attribute>
              <thumbnail_small>
                <xsl:value-of select="Image_Link_TN_5_1"/>
              </thumbnail_small>
              <thumbnail_medium>
                <xsl:value-of select="Image_Link_TN2_5_1"/>
              </thumbnail_medium>
              <medium>
                <xsl:value-of select="Image_Link_5_1"/>
              </medium>
              <large>
                <xsl:value-of select="Image_Link_5_1_Large"/>
              </large>
              <tiff/>
            </image>
            <image>
              <xsl:attribute name="is_primary">
                <xsl:value-of select="false()"/>
              </xsl:attribute>
              <thumbnail_small>
                <xsl:value-of select="Image_Link_TN_5_2"/>
              </thumbnail_small>
              <thumbnail_medium>
                <xsl:value-of select="Image_Link_TN2_5_2"/>
              </thumbnail_medium>
              <medium>
                <xsl:value-of select="Image_Link_5_2"/>
              </medium>
              <large>
                <xsl:value-of select="Image_Link_5_2_Large"/>
              </large>
              <tiff/>
            </image>
            <image>
              <xsl:attribute name="is_primary">
                <xsl:value-of select="false()"/>
              </xsl:attribute>
              <thumbnail_small>
                <xsl:value-of select="Image_Link_TN_5_3"/>
              </thumbnail_small>
              <thumbnail_medium>
                <xsl:value-of select="Image_Link_TN2_5_3"/>
              </thumbnail_medium>
              <medium>
                <xsl:value-of select="Image_Link_5_3"/>
              </medium>
              <large>
                <xsl:value-of select="Image_Link_5_3_Large"/>
              </large>
              <tiff/>
            </image>
            <image>
              <xsl:attribute name="is_primary">
                <xsl:value-of select="false()"/>
              </xsl:attribute>
              <thumbnail_small>
                <xsl:value-of select="Image_Link_TN_5_4"/>
              </thumbnail_small>
              <thumbnail_medium>
                <xsl:value-of select="Image_Link_TN2_5_4"/>
              </thumbnail_medium>
              <medium>
                <xsl:value-of select="Image_Link_5_4"/>
              </medium>
              <large>
                <xsl:value-of select="Image_Link_5_4_Large"/>
              </large>
              <tiff/>
            </image>
            <image>
              <xsl:attribute name="is_primary">
                <xsl:value-of select="false()"/>
              </xsl:attribute>
              <thumbnail_small>
                <xsl:value-of select="Image_Link_TN_5_5"/>
              </thumbnail_small>
              <thumbnail_medium>
                <xsl:value-of select="Image_Link_TN2_5_5"/>
              </thumbnail_medium>
              <medium>
                <xsl:value-of select="Image_Link_5_5"/>
              </medium>
              <large>
                <xsl:value-of select="Image_Link_5_5_Large"/>
              </large>
              <tiff/>
            </image>
          </images>

          <videos>
            <video>
              <xsl:attribute name="is_primary">
                <xsl:value-of select="true()"/>
              </xsl:attribute>
              <url>
                <xsl:value-of select="Video_File"/>
              </url>
              <embedded_code>
                <xsl:value-of select="Video_Embed_Code"/>
              </embedded_code>
            </video>
          </videos>
        </media>
        <instructions>
          <instruction>
            <xsl:value-of select="Instructions_File"/>
          </instruction>
        </instructions>
        <categories>
          <category>
            <xsl:attribute name="name">
              <xsl:value-of select="Section_Text" />
            </xsl:attribute>
            <category>
              <xsl:attribute name="name">
                <xsl:value-of select="Sub1" />
              </xsl:attribute>
            </category>
            <category>
              <xsl:attribute name="name">
                <xsl:value-of select="Sub2" />
              </xsl:attribute>
            </category>
          </category>
        </categories>
        <colors>
          <xsl:attribute name="multiple_colors">
            <xsl:value-of select="Color_Override"/>
          </xsl:attribute>
          <xsl:attribute name="style">
            <xsl:value-of select="Color_Style"/>
          </xsl:attribute>
          <color>
            <xsl:value-of select="Color_1"/>
          </color>
          <color>
            <xsl:value-of select="Color_2"/>
          </color>
          <color>
            <xsl:value-of select="Color_3"/>
          </color>
          <color>
            <xsl:value-of select="Color_4"/>
          </color>
        </colors>
        <tags>
          <xsl:value-of select="Keywords"/>
        </tags>
        <materials>
          <xsl:value-of select="Material"/>
        </materials>
        <suggestted_mpns>
          <suggestted_mpn>
            <xsl:value-of select="Suggest_1"/>
          </suggestted_mpn>
          <suggestted_mpn>
            <xsl:value-of select="Suggest_2"/>
          </suggestted_mpn>
          <suggestted_mpn>
            <xsl:value-of select="Suggest_3"/>
          </suggestted_mpn>
        </suggestted_mpns>
        <attributes>
          <attribute>
            <xsl:attribute name="waterproof">
              <xsl:value-of select="Waterproof" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="multispeed">
              <xsl:value-of select="Multispeed" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="silicone">
              <xsl:value-of select="Silicone" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="has_remote_control">
              <xsl:value-of select="Remote_Control" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="has_wireless_remote_control">
              <xsl:value-of select="Wireless_Remote_Controlled" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="batteries_included">
              <xsl:value-of select="Batteries_Included" />
            </xsl:attribute>
          </attribute>

          <attribute>
            <xsl:attribute name="condom_included">
              <xsl:value-of select="Condom_Included" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="crotchless">
              <xsl:value-of select="Crotchless" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="discreet">
              <xsl:value-of select="Discreet" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="dvd_Included">
              <xsl:value-of select="DVD_Included" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="flexible">
              <xsl:value-of select="Flexible" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="glows">
              <xsl:value-of select="Glow_In_The_Dark" />
            </xsl:attribute>
          </attribute>

          <attribute>
            <xsl:attribute name="harness_compatible">
              <xsl:value-of select="Harness_Compatible" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="jack_pin">
              <xsl:value-of select="Jack_Pin" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="lights_up">
              <xsl:value-of select="Light_Up" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="lube_included">
              <xsl:value-of select="Lube_Included" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="mask_included">
              <xsl:value-of select="Mask_Included" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="multi_vibration">
              <xsl:value-of select="Multi_Vibration" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="novelty">
              <xsl:value-of select="Novelty" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="cleaner">
              <xsl:value-of select="Cleans" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="suction_cup">
              <xsl:value-of select="Suction_Cup" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="toy_cleaner_included">
              <xsl:value-of select="Toy_Cleaner_Included" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="enlarges">
              <xsl:value-of select="Enlarges" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="escalates">
              <xsl:value-of select="Escalates" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="gyrates">
              <xsl:value-of select="Gyrates" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="pulsates">
              <xsl:value-of select="Pulsates" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="reverse_rotates">
              <xsl:value-of select="Reverse_Rotates" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="rotates">
              <xsl:value-of select="Rotates" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="vibrates">
              <xsl:value-of select="Vibrates" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="inflates">
              <xsl:value-of select="Inflates" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="ripples">
              <xsl:value-of select="Ripples" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="squirts">
              <xsl:value-of select="Squirts" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="sucks_and_pumps">
              <xsl:value-of select="Sucks_and_Pumps" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="talks">
              <xsl:value-of select="Talks" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="thrusts">
              <xsl:value-of select="Thrusts" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="warms">
              <xsl:value-of select="Warms" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="phthalates_free">
              <xsl:value-of select="phthalates_free" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="one_touch">
              <xsl:value-of select="One_Touch" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="multi_touch">
              <xsl:value-of select="Luv_Touch" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="numbing">
              <xsl:value-of select="Numbing" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="prostate">
              <xsl:value-of select="Prostate" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="g_spot">
              <xsl:value-of select="G_Spot" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="realistic">
              <xsl:value-of select="Realistic" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="single_entry">
              <xsl:value-of select="Single_Entry" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="multiple_entry">
              <xsl:value-of select="Multiple_Entry" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="ribbed">
              <xsl:value-of select="Ribbed" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="disposable_or_one_shot">
              <xsl:value-of select="Disposable_or_One_Shot" />
            </xsl:attribute>
          </attribute>
          <attribute>
            <xsl:attribute name="tapered">
              <xsl:value-of select="Tapered" />
            </xsl:attribute>
          </attribute>
        </attributes>
        <made_in>
          <xsl:value-of select="Country"/>
        </made_in>

        <dimensions>
          <item_dimensions>
            <weight>
              <xsl:value-of select="Item_Each_Weight"/>
            </weight>
            <length>
              <xsl:value-of select="Item_Each_Length"/>
            </length>
            <width>
              <xsl:value-of select="Item_Each_Width"/>
            </width>
            <height>
              <xsl:value-of select="Item_Each_Height"/>
            </height>
            <girth>
              <xsl:value-of select="Item_Each_Girth"/>
            </girth>
            <outer_diameter>
              <xsl:value-of select="Item_Outer_Diameter"/>
            </outer_diameter>
            <inner_diameter>
              <xsl:value-of select="Item_Inner_Diameter"/>
            </inner_diameter>
            <insertable_length>
              <xsl:value-of select="Insertable_Length"/>
            </insertable_length>
          </item_dimensions>
          <package_dimensions>
            <weight>
              <xsl:value-of select="Item_Each_Package_Weight"/>
            </weight>
            <length>
              <xsl:value-of select="Item_Each_Package_Length"/>
            </length>
            <width>
              <xsl:value-of select="Item_Each_Package_Width"/>
            </width>
            <height>
              <xsl:value-of select="Item_Each_Package_Height"/>
            </height>
          </package_dimensions>
        </dimensions>
        <electric_spec>
          <battary>
            <xsl:attribute name="is_primary">
              <xsl:value-of select="true()"/>
            </xsl:attribute>
            <xsl:attribute name="battery_type">
              <xsl:value-of select="Battery_1_Type"/>
            </xsl:attribute>
            <xsl:attribute name="battery_quantity">
              <xsl:value-of select="Battery_1_Quantity"/>
            </xsl:attribute>
            <xsl:attribute name="battery_substitute">
              <xsl:value-of select="Battery_1_Substitute"/>
            </xsl:attribute>
          </battary>
          <battary>
            <xsl:attribute name="is_primary">
              <xsl:value-of select="false()"/>
            </xsl:attribute>
            <xsl:attribute name="battery_type">
              <xsl:value-of select="Battery_2_Type"/>
            </xsl:attribute>
            <xsl:attribute name="battery_quantity">
              <xsl:value-of select="Battery_2_Quantity"/>
            </xsl:attribute>
            <xsl:attribute name="battery_substitute">
              <xsl:value-of select="Battery_2_Substitute"/>
            </xsl:attribute>
          </battary>
        </electric_spec>
      </xsl:for-each>
    </xml>
  </xsl:template>
</xsl:stylesheet>