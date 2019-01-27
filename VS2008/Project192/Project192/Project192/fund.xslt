<?xml version="1.0" encoding="euc-kr" ?>
<xsl:stylesheet version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <h3 align="center">주식 정보</h3>
    <table border="2" width="700" cellpadding="0" 
      cellspacing="0" align="center">
      <tr height="40">
        <td width="300" align="center"  bgcolor="#00ff00">주식명</td>
        <td width="200" align="center" bgcolor="00ff00">주식가격</td>
        <td width="200" align="center" bgcolor="00ff00">주식가격</td>
      </tr>
      <xsl:for-each select="kosdaq/stock">
        <tr height="35">
          <td width="300" align="center"  bgcolor="aliceblue">
            <bold><xsl:value-of select="stockname"/></bold>
          </td>
          <td width="200" align="center"  bgcolor="aliceblue">
            <xsl:value-of select="stockprice"/>
          </td>
          <td width="200" align="center"  bgcolor="aliceblue">
            <xsl:if test="prevstockprice[number(.) > 0]">
              <img src="fund/tri_red_up.gif"/>
              <xsl:value-of select="prevstockprice"/>
            </xsl:if>
            <xsl:if test="prevstockprice[number(.) &lt; 0]">
              <img src="fund/tri_blue_down.gif"/>
              <xsl:value-of select="-number(prevstockprice)"/>
            </xsl:if>
            <xsl:if test="prevstockprice[number(.) = 0]">
              0
            </xsl:if>
          </td>
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>