class StoreCustomer {

    constructor(private firstName:string, private lastName:string) {}

    public visits: number = 0;
    private ourName: string;

    public showName(): boolean {
        alert(`${this.firstName} ${this.lastName}`);
        return true;
    }

    set name(val) {
        this.ourName = val;
    }

    get name() {
        return this.ourName;
    }
}