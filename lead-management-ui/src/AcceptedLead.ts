export default class AcceptedLead {
    constructor(
        public contactFullName: string,
        public dateCreated: string,
        public suburb: string,
        public category: string,
        public jobId: number,
        public price: string,
        public contactPhoneNumber: string,
        public contactEmail: string,
        public description: string        
    ) {}
}