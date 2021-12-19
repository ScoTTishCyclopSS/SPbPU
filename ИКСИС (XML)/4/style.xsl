<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<head>
			<title>Задание 4</title>
			<style>
				table tr:nth-child(even) th {
					background-color: white;
				}
				table tr:nth-child(even) {
					background-color: blue;
				}
			</style>
		</head>
		<table border="2">
			<tr>
				<th rowspan="2">№<br/>пп</th>
				<th colspan="2">Имя</th>
				<th rowspan="2">Фамилия</th>
				<th colspan="2">Организация</th>
				<th rowspan="2">Домашний адрес</th>
				<th rowspan="2">Моб.<br/>телефон</th>
			</tr>
			<tr>
				<th>название</th>
				<th>адрес</th>
			</tr>
			<xsl:for-each select="/list_of_client/client">
				<xsl:sort select="last_name" order="descending"/>
				<tr>
					<td><xsl:value-of select="@id"/></td>
					<td><xsl:value-of select="first_name"/></td>
					<td><xsl:value-of select="last_name"/></td>
					<td><xsl:value-of select="organization/name"/></td>
					<td><xsl:value-of select="organization/address"/></td>
					<td><xsl:value-of select="home_address"/></td>
					<td><xsl:value-of select="phone/mobile_phone"/></td>
				</tr>
			</xsl:for-each>
		</table>
	</xsl:template>
</xsl:stylesheet>
<!-- <xsl:sort select="last_name" order="descending"/> -->