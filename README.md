# Shop-Backend

## API

### Регистрация 

path api/registration

Body
``` JSON
{
    "name": "string",
    "surname": "string",
    "email": "string",
    "phone": "string"
}
``` 

### Логин

path api/auth/login


Body
``` JSON
{
    "email": "string"
}
```

path api/auth/confirm

Body
``` JSON
{
    "email": "string",
    "code": "string"
}
```