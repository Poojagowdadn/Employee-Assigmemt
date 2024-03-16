import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ToolbarModule,
    ButtonModule,
    TableModule,
    TabViewModule,
    DropdownModule,
    TooltipModule,
    InputTextModule,
    CheckboxModule,
    ReactiveFormsModule,
    CalendarModule,
    ToastModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
