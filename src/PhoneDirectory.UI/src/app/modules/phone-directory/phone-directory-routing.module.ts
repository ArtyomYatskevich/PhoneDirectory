import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PhoneDirectoryComponent } from './components/phone-directory/phone-directory.component';

const routes: Routes = [{
  path: '',
  component: PhoneDirectoryComponent,
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhoneDirectoryRoutingModule { }
