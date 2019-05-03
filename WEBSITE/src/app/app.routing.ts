import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
// import { ParticipantsComponent } from '@pages/participants/participants.component';
export const ROUTES: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    // { path: 'callback', component: CallbackComponent },
    // { path: 'login', component: LoginComponent },
    // { path: 'schedule/:id', component: ScheduleComponent },
  ];
