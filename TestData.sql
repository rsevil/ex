insert into CreditCard (Number, Pin, ValidFrom, DueOn, InvalidLoginAttempts)
VALUES ('1111-2222-3333-4444', '123', GETDATE(), DATEADD(MONTH, 6, GETDATE()), 0)


SET IDENTITY_INSERT Operation ON

INSERT INTO Operation (Id, CreatedOn, CreditCardNumber, Amount, Discriminator)
VALUES (1,GETDATE(), '1111-2222-3333-4444', 200, 'WithdrawOperation')

INSERT INTO Operation (Id, CreatedOn, CreditCardNumber, Amount, Discriminator)
VALUES (2,GETDATE(), '1111-2222-3333-4444', 50, 'WithdrawOperation')

SET IDENTITY_INSERT Operation OFF