<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:param name="complexGlobalParam" >
    <collection>
      <testItem v="1" >Adam</testItem>
      <testItem v="2" >Bart</testItem>
    </collection>
  </xsl:param>

  <xsl:template match="/" >
    <ids>
      <xsl:apply-templates select="@* | node()"/>
    </ids>
  </xsl:template>

  <xsl:template  name="createArticle" >
    <xsl:param name="artId"  />
    <xsl:param name="article"  />
    <article>
      <title>
        <xsl:value-of select="$article/title/text()" disable-output-escaping="yes"/>
      </title>
      <xsl:variable name="mapNodes" select="msxsl:node-set($complexGlobalParam)/collection/testItem" />
      <author>
        <xsl:choose>
          <xsl:when test="$mapNodes[@v=$artId]" >
            <xsl:value-of select="$mapNodes[@v=$artId]/text()" />
          </xsl:when>
          <xsl:otherwise>Unknown</xsl:otherwise>
        </xsl:choose>
      </author>
    </article>
  </xsl:template>

  <xsl:template match="article">
    <xsl:variable name="articleId" select="@id" />
    <xsl:call-template name="createArticle" >
      <xsl:with-param name="artId" select="$articleId" />
      <xsl:with-param name="article" select="." />
    </xsl:call-template>
  </xsl:template>

  <xsl:template match="@* | node()">
    <xsl:apply-templates select="@* | node()"/>
  </xsl:template>
</xsl:stylesheet>
