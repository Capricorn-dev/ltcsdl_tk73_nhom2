import { Component } from '@angular/core';
declare var $: any;
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
    openNav() {
    document.getElementById("mySidenav").style.width = "195px";
    document.getElementById("main").style.marginLeft = "195px";
  }
  
  closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginLeft= "0";
  }
  openLoginModal() {
    $('#LoginModal').modal('show');
  }
}
