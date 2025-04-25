import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { debounceTime, Subject } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'list-item-data',  
  imports: [CommonModule,FormsModule],
  templateUrl: './list-item-data.component.html',
  styleUrl: './list-item-data.component.css'
})
export class ListItemDataComponent implements OnInit{

    // Event Emitter demo
    @Output() notifyParent: EventEmitter<any> = new EventEmitter();

    // two way binding for input text
    inputItem: string = '';  
    http = inject(HttpClient);
    private searchSubject = new Subject<string>();
    private readonly debounceTimeMs = 5000; // Set the debounce time (in milliseconds)

    @Input()
    list: any[]=[];
   
    // enable or disable visiblility of dropdown
    listHidden = true;
    showError = false;
    selectedIndex = -1;

    // the list to be shown after filtering
    filteredList: any[] = [];
    constructor() { }


  ngOnInit() {
    this.searchSubject.pipe(debounceTime(this.debounceTimeMs)).subscribe((inputItem) => {
       this.performSearch(inputItem);
    });
  }

  onSearch() {   
    this.searchSubject.next(this.inputItem);
  }

  performSearch(searchValue: string) {   
    this.getAllDDLItemsByParam(searchValue);
  }  

  getAllDDLItemsByParam(searchValue: string) {      
         this.http.get("https://localhost:7271/api/DropDownListItemsMaster/GetDropDownListItems?param=" + searchValue).subscribe((res: any) => {           
          this.list = res;   
          this.filteredList = this.list;          
      }); 
  }

  getFilteredList() {
    this.listHidden = false;
    if (!this.listHidden && this.inputItem !== undefined) {      
       this.filteredList = this.list.filter((item) =>  item.itemType.toLowerCase().startsWith(this.inputItem));
      }
}

// select highlighted item when enter is pressed or any item that is clicked
selectItem(ind: number) {   

    // Event Emitter demo: CHILD EMITS NOTIFICATION.
    //console.log('SELECTED itemType: ' + this.filteredList[ind].itemType);
    if(this.filteredList[ind] !== undefined)
    {
        this.notifyParent.emit(this.filteredList[ind].itemType);
        this.inputItem = this.filteredList[ind].itemType;    
        this.listHidden = true;
        this.selectedIndex = ind;
    }
}

// navigate through the list of items
onKeyPress(event: { key: string; }) {
    if (!this.listHidden) {
        if (event.key === 'Escape') {
            this.selectedIndex = -1;
            this.toggleListDisplay(0);
        }else if (event.key === 'Enter') {
            this.toggleListDisplay(0);
        }else if (event.key === 'ArrowDown') {
            this.listHidden = false;
            this.selectedIndex = (this.selectedIndex + 1) % this.filteredList.length;
            if (this.filteredList.length > 0 && !this.listHidden) {
                document.getElementsByTagName('list-item')[this.selectedIndex].scrollIntoView();
            }
        } else if (event.key === 'ArrowUp') {
            this.listHidden = false;
            if (this.selectedIndex <= 0) {
                this.selectedIndex = this.filteredList.length;
            }
            this.selectedIndex = (this.selectedIndex - 1) % this.filteredList.length;
            if (this.filteredList.length > 0 && !this.listHidden) {
            document.getElementsByTagName('list-item')[this.selectedIndex].scrollIntoView();
            }
        }
    }
}

// show or hide the dropdown list when input is focused or moves out of focus
toggleListDisplay(sender: number) {
    if (sender === 1) {
        this.listHidden = false;
        this.getFilteredList();
    } else {
        // helps to select item by clicking
        //console.log('SELECTED inputItem :' + this.inputItem); 
        if(this !== undefined)
        {
            setTimeout(() => {

                this.selectItem(this.selectedIndex);
              
                this.listHidden = true;
                if (!this.list.includes(this.inputItem)) {
                    this.showError = true;
                   
                    this.filteredList = this.list;
                } else {
                    this.showError = false;
                    
                }
    
            }, 5000);
        }

    }
}

}


