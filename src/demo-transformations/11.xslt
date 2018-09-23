<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    exclude-result-prefixes="msxsl"
    xmlns:demo="letsetdemoclass-demo-namespace"
>
  <xsl:output method="html" indent="yes"/>


  <xsl:template match="node()[@demo-action='remove']" >
  </xsl:template>

  <xsl:template match="node()[@demo-template='article']">
    <xsl:variable name="template" select="." />
    <xsl:value-of select="demo:DemoConcatArticleId(./@demo-template)"/>

  </xsl:template>

  <xsl:template match="@* | node()">
    <xsl:copy>
      <xsl:apply-templates select="@* | node()"/>
    </xsl:copy>
  </xsl:template>
</xsl:stylesheet>
