import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideClientHydration } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { routes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { HTTP_INTERCEPTORS, HttpClient, provideHttpClient } from '@angular/common/http';
import { AuthInterceptor } from './interceptors/auth.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideClientHydration(),
    FormsModule, provideAnimationsAsync(),
    HttpClient,
    provideHttpClient(),
    //{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ]
};