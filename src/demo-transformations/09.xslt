<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    exclude-result-prefixes="msxsl"
>
  <xsl:param name="simpleGlobalParam" >prefix</xsl:param>


  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/" >
    <ids>
      <xsl:apply-templates select="@* | node()"/>
    </ids>
  </xsl:template>

  <xsl:template match="article">
    <id value="{concat($simpleGlobalParam,'_',@id)}" />
  </xsl:template>

  <xsl:template match="@* | node()">
    <xsl:apply-templates select="@* | node()"/>
  </xsl:template>
</xsl:stylesheet>
