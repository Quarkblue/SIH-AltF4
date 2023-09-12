import userq from "../models/userq.js";

export default async function postHome(req,res){
    const {phone , query} = await req.body;
    const page = new userq({
        phone,
        query
    })
    await page.save().then(
        (op)=>{
            res.status(200).send(op);
        }
    )
}