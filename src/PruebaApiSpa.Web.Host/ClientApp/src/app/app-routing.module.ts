import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { CountriesComponent } from './countries/countries.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: '', component: CountriesComponent,  canActivate: [AppRouteGuard] }                 
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
