import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddEditPhoneComponent } from './components/add-edit-phone/add-edit-phone.component';
import { PhoneDirectoryComponent } from './components/phone-directory/phone-directory.component';
import { PhoneDirectoryRoutingModule } from './phone-directory-routing.module';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '@shared/shared.module';


@NgModule({
    declarations: [
        PhoneDirectoryComponent,
        AddEditPhoneComponent
    ],
    imports: [
        CommonModule,
        PhoneDirectoryRoutingModule,
        MatListModule,
        MatCardModule,
        MatButtonModule,
        MatIconModule,
        MatInputModule,
        MatDialogModule,
        FormsModule,
        ReactiveFormsModule,
        SharedModule
    ]
})
export class PhoneDirectoryModule { }
