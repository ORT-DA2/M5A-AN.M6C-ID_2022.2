import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { MovieFormComponent } from './components/movie-form/movie-form.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';
import { AuthGuard } from './guards/auth.guard';
import { RoleGuard } from './guards/role.guard';
import { ADMIN_URL, MOVIE_FORM_URL, MOVIE_LIST_URL } from './utils/routes';

const routes: Routes = [
  { path: '', component: MovieListComponent },
  { path: MOVIE_LIST_URL, component: MovieListComponent },
  {
    path: MOVIE_FORM_URL,
    component: MovieFormComponent,
    canActivate: [AuthGuard],
  },
  {
    path: ADMIN_URL,
    component: AdminComponent,
    canActivate: [RoleGuard],
    data: {
      expectedRole: 'admin'
    },
  },
  { path: '**', redirectTo: '' }, // this line goes at the end
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
