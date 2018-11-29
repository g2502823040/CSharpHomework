<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>The OrderList</title>
      </head>
      <body>    
<table width="100%" border="1" cellspacing="1" cellpadding="0"><tr>
              <td align="left" valign="middle">id</td>
              <td align="left" valign="middle" >name</td>
              <td align="left" valign="middle">customer</td>
	      <td align="left" valign="middle">money</td>
              <td align="left" valign="middle">phonenumber</td>
              <td align="left" valign="middle" >ordernumber</td>
            </tr></table>
<table>
        <xsl:apply-templates/>
    </table>    
   </body>
    </html>
  </xsl:template>
<xsl:template match="ArrayOfOrderDetail">
<xsl:apply-templates select="OrderDetail"/>
</xsl:template>
<xsl:template match="OrderDetail">
<table width="100%" border="1" cellspacing="1" cellpadding="0"><tr>
<td align="left" valign="middle">
            <xsl:value-of select="id"/>
</td>
<td align="left" valign="middle" >
            <xsl:value-of select="name"/>
</td>
<td align="left" valign="middle">
            <xsl:value-of select="customer"/>
</td>
<td align="left" valign="middle">
            <xsl:value-of select="money"/>
</td>
<td align="left" valign="middle">
            <xsl:value-of select="phonenumber"/>
</td>
<td align="left" valign="middle">
            <xsl:value-of select="ordernumber"/>
       </td>
    </tr></table>
</xsl:template>

</xsl:stylesheet>