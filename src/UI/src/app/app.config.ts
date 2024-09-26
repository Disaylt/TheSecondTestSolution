import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient, withInterceptorsFromDi, HTTP_INTERCEPTORS, withFetch } from '@angular/common/http';
import { ErrorHttpInterceptor } from './core/interceptor/error-http-interceptor';
import { HostHttpInterceptor } from './core/interceptor/host-http-interceptor';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideClientHydration(), provideAnimationsAsync(),
    provideHttpClient(withInterceptorsFromDi(), withFetch()),
    {provide : HTTP_INTERCEPTORS, useClass : ErrorHttpInterceptor, multi: true},
    {provide : HTTP_INTERCEPTORS, useClass : HostHttpInterceptor, multi: true}
  ]
};
