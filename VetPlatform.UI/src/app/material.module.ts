import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatButtonModule, MatToolbarModule, MatDatepickerModule, MatFormFieldModule, MatNativeDateModule, MatInputModule, MatIconModule, MatCardModule, MatProgressSpinnerModule, MatChipsModule, MatDialogModule, MatButtonToggleModule} from '@angular/material'

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
        MatButtonToggleModule
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
        MatButtonToggleModule
    ],
    providers: [],
})
export class MaterialModule {}