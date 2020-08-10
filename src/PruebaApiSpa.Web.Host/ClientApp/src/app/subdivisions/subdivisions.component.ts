import { ProvinceInputDto } from './../../shared/service-proxies/service-proxies';
import { SearchDto, SubdivisionServiceProxy, ProvinceDtoContextDto, ProvinceDto } from '@shared/service-proxies/service-proxies';
import { Component, OnInit, Injector, Input, Output, EventEmitter } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'app-subdivisions',
    templateUrl: './subdivisions.component.html',
    styleUrls: ['./subdivisions.component.scss']
})
export class SubdivisionsComponent extends AppComponentBase implements OnInit {
    filters: SearchDto = new SearchDto();
    contextSubdivision: ProvinceDtoContextDto = new ProvinceDtoContextDto();
    subdivisionNewEdit: ProvinceInputDto;
    advancedFiltersVisible: boolean = false;
    isTableLoading: boolean = false;
    isActive: boolean = false;
    totalItem: number = 0;

    @Output() onSave = new EventEmitter<any>();

    @Input("country-id") countryId: number;
    saving: boolean;

    constructor(private injector: Injector,
        private _subdivisionService: SubdivisionServiceProxy) {
        super(injector);
        this.filters.page = 1;
        this.filters.pageSize = 5;
    }

    ngOnInit(): void {
        this.filters.countryId = this.countryId;
        console.log(this.filters);
        this.getDataPage(1);
    }


    getDataPage(page: number) {
        if (!this.isTableLoading) {
            this.filters.page = page;
            this.isTableLoading = true;
            this._subdivisionService.getAll(this.filters).subscribe(result => {
                this.contextSubdivision = result;
                this.isTableLoading = false;
                this.totalItem = this.contextSubdivision.metaData.totalItemCount;
                console.log(this.contextSubdivision);
            });
        }
    }

    pageChanged(event) {
        this.getDataPage(event);
    }

    createSubdivision() {
        this.showCreateEditSubdivisionDialog();
    }

    editSubdivision(subdivision: ProvinceDto) {
        this.showCreateEditSubdivisionDialog(subdivision);
    }

    deleteSubdivision(subdivision: ProvinceDto) {
        abp.message.confirm(
            "Subdivision " + subdivision.subDivisionName + " will be deleted.",
            undefined,
            (result: boolean) => {
                if (result) {
                    this._subdivisionService.delete(subdivision.id).subscribe(() => {
                        abp.notify.success(this.l('SuccessfullyDeleted'));
                        this.getDataPage(1);
                        this.onSave.emit();
                    });
                }
            }
        );
    }

    showCreateEditSubdivisionDialog(subdiv?: ProvinceDto) {
        this.subdivisionNewEdit = new ProvinceInputDto();
        this.subdivisionNewEdit.countryId = this.countryId;
        if (subdiv != null) {
            this.subdivisionNewEdit.id = subdiv.id;
            this.subdivisionNewEdit.code = subdiv.code;
            this.subdivisionNewEdit.subDivisionName = subdiv.subDivisionName;
        }
    }

    save() {
        if (this.subdivisionNewEdit != null) {
            this.saving = true;
            this._subdivisionService.addOrUpdate(this.subdivisionNewEdit)
                .pipe(
                    finalize(() => {
                        this.saving = false;
                    })
                )
                .subscribe(() => {
                    this.notify.info(this.l('SavedSuccessfully'));
                    this.cancel();
                    this.getDataPage(1);
                    this.onSave.emit();
                });
        }
    }

    cancel() {
        this.subdivisionNewEdit = null;
    }
}
