# Certificate Management Notes

Databases pass initial validation.

```bash
    certutil -d sql:$HOME/.pki/nssdb -A -t "P,," -n localhost -i ./localhost.crt
```
```
> Pass: Certificate is valid and supported within chrome without further modification.
```

```bash
    certutil -d sql:$HOME/.pki/nssdb -A -t "C,," -n localhost -i ./localhost.crt
```
```
> Fail. Certificate is not modifiable.
```

DotNet already provides the methods to generate the certificate.

## TODO

>
> - **Passwords**
>   - Generating the initial certs requested password
>   - Exporting the initial certs reqested
>   - Importing into db requested
> - *Get & store the password securely and supply the same password for each prompt*
>

- Map certificate properties to corresponding db columns 
- Configure sqlite to cleanup write-ahead logs and database shims.
