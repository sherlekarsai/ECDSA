# ECDSA
Cryptography ECC algo where you can generate verify and read, save keys


When you search ECDSA on internet, you will get many more articles but use this link to understand
ECC Algorithm very well. ECC Algorithm is maths program, you need three parameters x, y for EC
point public key and x for private. Calculate random number k in range [1-n-1], Calculate EC point x *
y and calculate signature(r,s). Use Bouncy castle open source library to generate signature.
First hash input data and then encodes through ECC curve using private key and generate numbers s
which is proof that signer knows or verify using of private key.
Signature verification method decodes s and using r and private key. Complete maths is clearly  https://cryptobook.nakov.com/digital-signatures/ecdsa-sign-verify-messages
Using Code:

Code has major parts:
1. Generate Key pair
2. Save Public Key and Private key
3. Generate Signature using private key
4. Verify signature using saved public key
5. Generate, verify signature with random key pair
