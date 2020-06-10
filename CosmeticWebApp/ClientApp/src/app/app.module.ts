import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CategoryComponent } from './category/category.component';
import { BrandComponent } from './brand/brand.component';
import { ProductComponent } from './product/product.component';
import { OrderComponent } from './order/order.component';
import { ProfileComponent } from './profile/profile.component';
import { SignupComponent } from './signup/signup.component';
import { TeamComponent } from './team/team.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CategoryComponent,
    BrandComponent,
    ProductComponent,
    OrderComponent,
    ProfileComponent,
    SignupComponent,
    TeamComponent
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'category', component: CategoryComponent },
      { path: 'brand', component: BrandComponent },
      { path: 'product', component: ProductComponent },
      { path: 'order', component: OrderComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'signup', component: SignupComponent },
      { path: 'team', component: TeamComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
