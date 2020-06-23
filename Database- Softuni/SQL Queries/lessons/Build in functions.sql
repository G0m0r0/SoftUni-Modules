Use Demo

--replace the rest of the length with asteriks
SELECT FirstName,
	LastName,
	PaymentNumber,
	LEFT(PaymentNumber,6)+Replicate('*', LEN(PaymentNumber)-6) AS PaymentNumber
	 FROM Customers

