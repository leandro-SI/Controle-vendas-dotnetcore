import { EstadoDto } from './estadoDto';

export class EstadoDtoPagedResultDto implements IEstadoDtoPagedResultDto {
    totalCount: number;
    items: EstadoDto[] | undefined;

    constructor(data?: IEstadoDtoPagedResultDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.totalCount = data["totalCount"];
            if (Array.isArray(data["items"])) {
                this.items = [] as any;
                for (let item of data["items"])
                    this.items.push(EstadoDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): EstadoDtoPagedResultDto {
        data = typeof data === 'object' ? data : {};
        let result = new EstadoDtoPagedResultDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["totalCount"] = this.totalCount;
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        return data; 
    }

    clone(): EstadoDtoPagedResultDto {
        const json = this.toJSON();
        let result = new EstadoDtoPagedResultDto();
        result.init(json);
        return result;
    }
}

export interface IEstadoDtoPagedResultDto {
    totalCount: number;
    items: EstadoDto[] | undefined;
}