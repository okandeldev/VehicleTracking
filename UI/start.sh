#!/bin/sh
sed -i "s/employee-dev.example.com/employee-$CONFIGURATION.example.com/g" /usr/share/nginx/html/main.*.js
nginx -g 'daemon off;
