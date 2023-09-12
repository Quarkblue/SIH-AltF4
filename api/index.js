import express, { urlencoded } from "express"
import mongoose from "mongoose"
import cors from "cors"
import dotenv from "dotenv"

//importing controllers
import getHome from "./controllers/getHome.js"
import postHome from "./controllers/postHome.js"

//init express app
const app = express();

//middleware
dotenv.config();
app.use(cors({preflightContinue:true}));
app.use(express.json());

//importing EV
const PORT = process.env.PORT;
const MONGO = process.env.MONGO;

//hc
app.use("/api/v1/hc",(_,res)=>{
    res.status(200).send({
        "Health Check":"OK"
    })
})

app.get("/api/v1/home",getHome);
app.post("/api/v1/home",postHome);

//listener
mongoose.connect(MONGO).then(
    ()=>{
        app.listen(PORT,()=>{
            console.log("listening");
        })
        
    }
)