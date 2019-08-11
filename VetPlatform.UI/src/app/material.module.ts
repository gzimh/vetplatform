import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatButtonModule, MatToolbarModule, MatDatepickerModule, MatFormFieldModule, MatNativeDateModule, MatInputModule, MatIconModule, MatCardModule, MatProgressSpinnerModule, MatChipsModule, MatDialogModule, MatButtonToggleModule, MatSnackBar, MatSnackBarModule} from '@angular/material'

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        MatButtonModule,
        MatToolbarModule,
        MatDatepickerModule,
        MatFormFieldModule,
        MatNativeDateModule,
        MatInputModule,
        MatIconModule,
        MatCardModule,
        MatProgressSpinnerModule,
        MatChipsModule,
        MatDialogModule,
        MatButtonToggleModule,
        MatSnackBarModule
    ],
    exports: [
        MatButtonModule,
        MatToolbarModule,
        MatDatepickerModule,
        MatFormFieldModule,
        MatNativeDateModule,
        MatInputModule,
        MatIconModule,
        MatCardModule,
        MatProgressSpinnerModule,
        MatChipsModule,
        MatDialogModule,
        MatButtonToggleModule,
        MatSnackBarModule
    ],
    providers: [],
})
export class MaterialModule {}
