export default class NewLead {
    constructor(
        public contactFirstName: string,
        public dateCreated: string,
        public suburb: string,
        public category: string,
        public jobId: number,
        public description: string,
        public price: string
    ) {}
}
