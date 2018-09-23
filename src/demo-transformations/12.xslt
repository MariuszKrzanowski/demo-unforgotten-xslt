<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    xmlns:demo="letsetdemoclass-demo-namespace"
    xmlns:xhtml="http://www.w3.org/1999/xhtml"
    exclude-result-prefixes="msxsl xhtml demo"
    
>
  <xsl:output method="html" indent="yes"/>


  <xsl:template match="node()[@demo-action='remove']" >
  </xsl:template>

  <xsl:template match="node()[@demo-template='article']">
    <xsl:variable name="template" select="." />
    <xsl:variable name="articles" select="demo:GetArticles()"/>

    <xsl:for-each select="$articles/demoroot/article">
      <xsl:variable name="articleData" select="." />
      <div class="article" xmlns="http://www.w3.org/1999/xhtml" >
        <h2>
          <xsl:value-of select="$articleData/title" disable-output-escaping="no"/>
        </h2>
        <div>
          <xsl:value-of select="$articleData/content" disable-output-escaping="yes" />
        </div>
      </div>
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="@* | node()">
    <xsl:copy>
      <xsl:apply-templates select="@* | node()"/>
    </xsl:copy>
  </xsl:template>
</xsl:stylesheet>
