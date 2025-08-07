import { Injectable } from '@angular/core';
import { HttpInterceptorFn } from '@angular/common/http';

export const BasicAuthInterceptor: HttpInterceptorFn = (req, next) => {
  const username = localStorage.getItem('username');
  const password = localStorage.getItem('password');

  if (username && password) {
    const authHeader = 'Basic ' + btoa(`${username}:${password}`);
    const authReq = req.clone({
      headers: req.headers.set('Authorization', authHeader)
    });
    return next(authReq);
  }
  return next(req);
};
