# ECDSA
C# code of Cryptography ECC algo where you can generate verify and read, save keys


When you search C# ECDSA on internet, you will get many more articles but use this link to understand
ECC Algorithm very well. ECC Algorithm is asymmetric cryptography where you get public and private key.

Using private key you can sign data and through public key you can verify.

This algo is Complete maths is clearly  https://cryptobook.nakov.com/digital-signatures/ecdsa-sign-verify-messages
Using Code:

Code has major parts:
1. Generate Key pair
2. Save Public Key and Private key
3. Generate Signature using private key
4. Verify signature using saved public key
5. Generate, verify signature with random key pair
