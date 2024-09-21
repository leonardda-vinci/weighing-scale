psql -U tplinux -c "\copy (select * from plu where get_bit(pluflags,10)=1) to /home/tplinux/in/plu.iu DELIMITER '|';"
import/rcs_importer master
