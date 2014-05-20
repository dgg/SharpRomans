<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="text" indent="no" />
<xsl:template match="Story">
#&#x20;<xsl:value-of select="@Name"/>
<xsl:apply-templates />
</xsl:template>
<xsl:template match="Result[@IndentLevel = 1]">
__<xsl:value-of select="@Prefix"/>__&#x20;<xsl:value-of select="@Text" />
</xsl:template>
<xsl:template match="Result[@IndentLevel = 3]">
## <xsl:value-of select="@Text" />
</xsl:template>
<xsl:template match="Result[@IndentLevel = 4]">
*&#x20;__<xsl:value-of select="@Prefix" />__&#x20;<xsl:value-of select="@Text" />
</xsl:template>
<xsl:template match="Result[@IndentLevel = 5]">
&#x9;*&#x20;__<xsl:value-of select="@Prefix" />__&#x20;<xsl:value-of select="@Text" />
</xsl:template>
<xsl:strip-space elements="Tag"/> 
<xsl:template match="Tag"></xsl:template>
</xsl:stylesheet>
